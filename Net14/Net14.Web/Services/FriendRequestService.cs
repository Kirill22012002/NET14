﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.DbModel.SocialDbModels.SocialEnums;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.SignalRHubs;

namespace Net14.Web.Services
{
    public class FriendRequestService
    {
        private UserFriendRequestRepository _userFriendRequestRepository;
        private SocialUserRepository _socialUserRepository;
        private IHubContext<NotificationsHub> _notificationHub;

        [AutoRegister]
        public FriendRequestService( UserFriendRequestRepository userFriendRequestRepository,
            SocialUserRepository socialUserRepository, IHubContext<NotificationsHub> hub)
        {
            _notificationHub = hub;
            _userFriendRequestRepository = userFriendRequestRepository;
            _socialUserRepository = socialUserRepository;
        }

        public void CreateFriendRequest(int  senderId, int receiverId)
        {
            if (!Exists(senderId, receiverId) && _socialUserRepository.Exists(senderId) && _socialUserRepository.Exists(receiverId))
            {
                var sender = _socialUserRepository.Get(senderId);
                var reciver = _socialUserRepository.Get(receiverId);
                var friendRequest = new UserFriendRequest
                {
                    Sender = sender,
                    Receiver = reciver,
                    FriendRequestStatus = FriendRequestStatus.Pending
                };

                _userFriendRequestRepository.Save(friendRequest);
            }
        }

        public void Accept(int senderId, int receiverId)
        {
            if (Exists(senderId, receiverId) && _socialUserRepository.Exists(senderId) && _socialUserRepository.Exists(receiverId))
            {
                var rec = _socialUserRepository.Get(receiverId);
                var send = _socialUserRepository.Get(senderId);
                var friendRequest = _userFriendRequestRepository.GetAll().FirstOrDefault(fr => fr.Receiver.Id == rec.Id && fr.Sender.Id == send.Id);
                friendRequest.FriendRequestStatus = FriendRequestStatus.Accepted;
                _userFriendRequestRepository.Save(friendRequest);
                MakeFriends(senderId, receiverId);

            }
        }
        public void Decline(int senderId, int receiverId) 
        {
            if (Exists(senderId, receiverId) && _socialUserRepository.Exists(senderId) && _socialUserRepository.Exists(receiverId)) 
            {
                var sender = _socialUserRepository.Get(senderId);
                var recive = _socialUserRepository.Get(receiverId);
                var friendRequest = _userFriendRequestRepository.GetAll();
                var target = friendRequest.Single(req => req.Receiver == recive && req.Sender == sender && req.FriendRequestStatus == FriendRequestStatus.Pending);
                target.FriendRequestStatus = FriendRequestStatus.Declined;

                _userFriendRequestRepository.Save(target);
            }
        }

        private bool Exists(int senderId, int receiverId)
        {
            var send = _socialUserRepository.Get(senderId);
            var receive = _socialUserRepository.Get(receiverId);
            return _userFriendRequestRepository.GetAll()
                .Where(request => request.FriendRequestStatus == FriendRequestStatus.Pending)
                .Any(fr => fr.Sender == send && fr.Receiver == receive);
        }

        public bool CheckIfFriends(int requestUserId, int targetUserId)
        {
            var user = _socialUserRepository.Get(requestUserId);
            var user2 = _socialUserRepository.Get(targetUserId);

            return user.Friends.Contains(user2);
        }

        public void MakeFriends(int senderId, int receiverId)
        {
            if (_socialUserRepository.Get(senderId) != null && _socialUserRepository.Get(senderId) != null &&
               !CheckIfFriends(senderId, receiverId))
            {
                var sender = _socialUserRepository.Get(senderId);
                var rec = _socialUserRepository.Get(receiverId);

                sender.Friends.Add(rec);
                rec.Friends.Add(sender);

                _socialUserRepository.Save(sender);
                _socialUserRepository.Save(rec);

            }
        }
    }
}

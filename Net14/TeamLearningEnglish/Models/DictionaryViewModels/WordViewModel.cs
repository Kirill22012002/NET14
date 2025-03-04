﻿using System.Collections.Generic;
using TeamLearningEnglish.EfStuff.DbModels;

namespace TeamLearningEnglish.Models
{
    public class WordViewModel
    {
        public int Id { get; set; }
        public string EnglishWord { get; set; }
        public string RussianWord { get; set; }
        public int Importance { get; set; }
        public string Folder { get; set; }
        public List<string> AllFolders { get; set; }
        public List<string> Comments { get; set; }
    }
}

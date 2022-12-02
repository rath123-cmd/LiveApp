﻿using LiveApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveApp.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}
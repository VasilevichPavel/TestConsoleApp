﻿using TestConsoleApp.Core.Models;

namespace TestConsoleApp.Core.Services.Interfaces
{
    public interface IDisplayService
    {
        void Show(IEnumerable<Repository> repositories);
        void Show(IEnumerable<Repository> repositories, string title);
    }
}

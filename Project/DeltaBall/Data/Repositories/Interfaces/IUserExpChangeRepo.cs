﻿using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IUserExpChangeRepo
    {
        public UserExpChange GetExpChangeById(Guid id);

        public IEnumerable<UserExpChange> GetExpChanges();

        public void SaveExpChange(UserExpChange obj);

        public bool DeleteExpChange(UserExpChange obj);
    }
}

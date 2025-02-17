﻿using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public class PlayerLogic : IPlayerLogic
    {
        IRepository<Player> pRepo;

        public PlayerLogic(IRepository<Player> playerRepo)
        {
            this.pRepo = playerRepo;
        }

        public void Create(Player item)
        {
            pRepo.Create(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Player Read(int id)
        {
            return pRepo.Read(id);
        }

        public IQueryable<Player> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Player item)
        {
            throw new NotImplementedException();
        }

        // pont számítás
        // pohár számítás
        // két player összehasonlítása ezek alapján
        
    }
}

using BracketMaster.Logic;
using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Service
{
    public class GroupService<T, K> : IGroupService<T, K>
        where T : Group
        where K : Player
    {
        readonly IGroupRepository<T> _groupRepository;
        readonly IGroupLogic<T> _groupLogic;

        readonly IPlayerService<K> _playerService;

        public GroupService(IGroupRepository<T> groupRepository, IGroupLogic<T> groupLogic, IPlayerService<K> playerService)
        {
            _groupRepository = groupRepository;
            _groupLogic = groupLogic;
            _playerService = playerService;
        }

        public void AddPlayer(int groupId, int playerId)
        {
            var group = _groupRepository.Read(groupId);
            if (group == null) throw new Exception("Group not found");

            var player = _playerService.Read(playerId);
            if (player == null) throw new Exception("Player not found");

            if (player.TournamentId != group.TournamentId)
                throw new Exception("This player's and the group's tournament is different!");

            player.GroupId = groupId;
            _playerService.Update(player);
        }

        public void Create(T item)
        {
            try
            {
                _groupLogic.Validate(item);
                _groupRepository.Create(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _groupRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public T Read(int id)
        {
            try
            {
                return _groupRepository.Read(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<T> ReadAll()
        {
            try
            {
                return _groupRepository.ReadAll();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Update(T item)
        {
            try
            {
                _groupLogic.Validate(item);
                _groupRepository.Update(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}

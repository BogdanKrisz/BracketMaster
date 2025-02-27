using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public class BeerpongTournamentLogic : TournamentLogic<BeerpongTournament, BeerpongTournamentPlayer, BeerpongPlayer>
    {
        public BeerpongTournamentLogic(IRepository<BeerpongTournament> beerpongTournamentRepo, ITournamentPlayerLogic<BeerpongTournamentPlayer> beerpongTournamentPlayerLogic, IPlayerLogic<BeerpongPlayer> beerpongPlayerLogic) 
            : base(beerpongTournamentRepo, beerpongTournamentPlayerLogic, beerpongPlayerLogic)
        {

        }

        public override void Create(BeerpongTournament item)
        {
            if (item.PointsForOverTimeWin < item.PointsForOverTimeLose) throw new ArgumentException("Overtime win points can't be lower than overtime lose points!");

            base.Create(item);
        }

        public override void Update(BeerpongTournament item)
        {
            if (item.PointsForOverTimeWin < item.PointsForOverTimeLose) throw new ArgumentException("Overtime win points can't be lower than overtime lose points!");

            base.Update(item);
        }

        // NON - CRUD
        public override void AddPlayer(int tournamentId, int playerId)
        {
            BeerpongTournament tournament = Read(tournamentId);
            BeerpongPlayer player = _playerLogic.Read(playerId);

            // kötő táblába új rekord illesztés
            BeerpongTournamentPlayer tournamentPlayer = new BeerpongTournamentPlayer();
            tournamentPlayer.TournamentId = tournamentId;
            tournamentPlayer.PlayerId = playerId;
            _tournamentPlayerLogic.Create(tournamentPlayer);

            // player példányban a résztvett bajnokságId átírása
            player.TournamentId = tournamentId;
            _playerLogic.Update(player);
        }
    }
}

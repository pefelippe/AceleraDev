using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;
using Source;

namespace Codenation.Challenge
{
    // adicionar metodos de validação
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        Dictionary<long, Team> DictTeams;
        Dictionary<long, Player> DictPlayers;

        public SoccerTeamsManager()
        {
            DictTeams = new Dictionary<long, Team>();
            DictPlayers = new Dictionary<long, Player>();
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            CheckTeamID(id);

            Team NewTeam = new Team()
            {
                id = id,
                name = name,
                dataCriacao = createDate,
                corUniformePrincipal = mainShirtColor,
                corUniformeSecundario = secondaryShirtColor
            };

            DictTeams.Add(NewTeam.id, NewTeam);
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            CheckPlayerId(id);
            ExistTeamId(teamId);

            Player NewPlayer = new Player()
            {
                id = id,
                teamId = teamId,
                name = name,
                birthDate = birthDate,
                skillLevel = skillLevel,
                salary = salary
            };

            DictPlayers.Add(NewPlayer.id, NewPlayer);
        }

        public void SetCaptain(long playerId) 
        {
            ExistPlayerId(playerId);
            long PlayerTeamId = DictPlayers[playerId].teamId;
            DictTeams[PlayerTeamId].IdCaptain = playerId;
        }

        public long GetTeamCaptain(long teamId) 
        {
            ExistTeamId(teamId);

            if (DictTeams[teamId].IdCaptain == 0) // Captain not Exists
            {
                throw new Codenation.Challenge.Exceptions.CaptainNotFoundException();
            }
            return DictTeams[teamId].IdCaptain;
        }

        public string GetPlayerName(long playerId)
        {
            ExistPlayerId(playerId);
            return DictPlayers[playerId].name;
        }

        public string GetTeamName(long teamId)
        {
            ExistTeamId(teamId);
            return DictTeams[teamId].name;
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            ExistTeamId(teamId);
            List<Player> TeamPlayers = new List<Player>(DictPlayers.Values);
            return TeamPlayers
                .Where(p => p.teamId == teamId)
                .Select(p => p.id)
                .OrderBy(o => o)
                .ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            int BestSkill = 0;
            long BestPlayerId = 0;

            ExistTeamId(teamId);

            foreach (Player p in DictPlayers.Values.Where(p => p.teamId == teamId))
            {
                if ((p.skillLevel > BestSkill) || (p.skillLevel == BestSkill && p.id < BestPlayerId))
                {
                   
                    BestSkill = p.skillLevel;
                    BestPlayerId = p.id;
                }
            }

            return BestPlayerId;
        }

        public long GetOlderTeamPlayer(long teamId) 
        {
            DateTime OlderAge = DateTime.Today;
            long OlderPlayerId = 0;

            ExistTeamId(teamId);

            foreach (Player p in DictPlayers.Values.Where(p => (p.teamId == teamId)))
            {
                int result = DateTime.Compare(OlderAge, p.birthDate);
                if  (result > 0)
                {
                    OlderAge = p.birthDate;
                    OlderPlayerId = p.id;
                }
            }

            return OlderPlayerId;
        }

        public List<long> GetTeams() 
        {
            List<long> AllTeams = new List<long>(DictTeams.Keys);

            return AllTeams.OrderBy(o => o).ToList();

        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            decimal HighestSalary = 0;
            long RichestPlayerId = 0;

            ExistTeamId(teamId);

            foreach (Player p in DictPlayers.Values.Where(p=> p.teamId == teamId))
            {
                if (p.salary > HighestSalary || (p.salary == HighestSalary && p.id < RichestPlayerId))      
                {
                    HighestSalary = p.salary;
                    RichestPlayerId = p.id;
                }
            }

            return RichestPlayerId;
        }

        public decimal GetPlayerSalary(long playerId)
        {
            ExistPlayerId(playerId);
            return DictPlayers[playerId].salary;
        }

        public List<long> GetTopPlayers(int top) 
        {
            List<Player> AllPlayers = new List<Player>(DictPlayers.Values);
            return (AllPlayers.OrderByDescending(x => x.skillLevel)
                .Take(top)
                .Select(player => player.id))
                .ToList();
            
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            ExistTeamId(teamId);
            ExistTeamId(visitorTeamId);

            if (DictTeams[visitorTeamId].corUniformePrincipal == DictTeams[teamId].corUniformePrincipal)
            {
                return DictTeams[visitorTeamId].corUniformeSecundario;
            }

            return DictTeams[visitorTeamId].corUniformePrincipal;
        }

        // MÉTODOS DE CHECAGEM

        // Exceção de tentar duplicar um ID
        private void CheckTeamID(long id)
        {
            if (DictTeams.ContainsKey(id)) // Time não Encontrado
            {
                throw new Codenation.Challenge.Exceptions.UniqueIdentifierException();
            }
        }

        private void CheckPlayerId(long id)
        {
            if (DictPlayers.ContainsKey(id)) // Time não Encontrado
            {
                throw new Codenation.Challenge.Exceptions.UniqueIdentifierException();
            }
        }

        // Exceção ao procurar um ID invalido
        private void ExistTeamId(long id)
        {
            if (!(DictTeams.ContainsKey(id))) // Time não Encontrado
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }
        }

        private void ExistPlayerId(long id)
        {
            if (!(DictPlayers.ContainsKey(id)))
            {
                throw new Codenation.Challenge.Exceptions.PlayerNotFoundException();
            }
        }


    }
}

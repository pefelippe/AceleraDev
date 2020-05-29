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
            List<long> TeamPlayers = new List<long>();

            foreach (Player p in DictPlayers.Values)
            {
                if (p.teamId == teamId)
                {
                    TeamPlayers.Add(p.id);
                }
            }

            return TeamPlayers;
        }

        public long GetBestTeamPlayer(long teamId)
        {
            int BestSkill = 0;
            long BestPlayerId = 0;

            ExistTeamId(teamId);

            foreach (Player p in DictPlayers.Values)
            {
                if ((p.teamId == teamId) && (p.skillLevel > BestSkill))
                {
                    BestSkill = p.skillLevel;
                    BestPlayerId = p.id;
                }
            }

            return BestPlayerId;
        }

        public long GetOlderTeamPlayer(long teamId) //**** FUNCIONA?
        {
            DateTime OlderAge = new DateTime(0);
            long OlderPlayerId = 0;

            ExistTeamId(teamId);

            foreach (Player p in DictPlayers.Values)
            {
                DateTime age = p.birthDate;
                int result = DateTime.Compare(OlderAge, age);
                if ((p.teamId == teamId) && (result > 0))
                {
                    OlderAge = age;
                    OlderPlayerId = p.id;
                }
            }

            return OlderPlayerId;
        }

        public List<long> GetTeams() //**** FUNCIONA?
        {
            List<Team> AllTeams = new List<Team>(DictTeams.Values);

            return AllTeams.OrderBy(x => x.id).Select(x => x.id).ToList();
            
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            decimal HighestSalary = 0;
            long RichestPlayerId = 0;

            ExistTeamId(teamId);

            foreach (Player p in DictPlayers.Values)
            {
                if ((p.teamId == teamId) && (p.salary > HighestSalary))
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

        public List<long> GetTopPlayers(int top) //******
        {
            List<long> TopPlayers = new List<long>();
            return TopPlayers;
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

        // Antes de Adicionar Novos IDs
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

        // Consultar ID's
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

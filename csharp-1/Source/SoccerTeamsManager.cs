using System;
using System.Collections.Generic;
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
            if (DictTeams.ContainsKey(id)) // Time não Encontrado
            {
                throw new Codenation.Challenge.Exceptions.UniqueIdentifierException();
            }

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
            if (DictPlayers.ContainsKey(id)) // PlayerID já cadastrado
            {
                throw new Codenation.Challenge.Exceptions.UniqueIdentifierException();
            }

            if (!(DictTeams.ContainsKey(teamId))) // Time não Encontrado
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

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
    
        public void SetCaptain(long playerId) //********
        {
            if (!(DictPlayers.ContainsKey(playerId))) // PlayerID já cadastrado
            {
                throw new Codenation.Challenge.Exceptions.PlayerNotFoundException();
            }

            DictTeams[DictPlayers[playerId].teamId].captain = playerId;
        }

        public long GetTeamCaptain(long teamId) //********
        {
            if (!(DictTeams.ContainsKey(teamId)))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

            return DictTeams[teamId].captain;
        } 

        public string GetPlayerName(long playerId)
        {
            if (!(DictPlayers.ContainsKey(playerId)))
            {
                throw new Codenation.Challenge.Exceptions.PlayerNotFoundException();
            }

            return DictPlayers[playerId].name;
        }

        public string GetTeamName(long teamId)
        {
            if (!(DictTeams.ContainsKey(teamId)))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

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

            if (!(DictTeams.ContainsKey(teamId)))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

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

        public long GetOlderTeamPlayer(long teamId) //*********
        {
            int OlderAge = 0;
            long OlderPlayerId = 0;

            if (!(DictTeams.ContainsKey(teamId)))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

            foreach (Player p in DictPlayers.Values)
            {
                int age = 0; // como fazer ???
                if ((p.teamId == teamId) && (age > OlderAge))
                {
                    OlderAge = age;
                    OlderPlayerId = p.id;
                }
            }

            return OlderPlayerId;
        }

        public List<long> GetTeams()
        {
            List<long> AllTeams = new List<long>(DictTeams.Keys);
            return AllTeams;
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            decimal HighestSalary = 0;
            long RichestPlayerId = 0;

            if (!(DictTeams.ContainsKey(teamId)))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

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
            if (!(DictPlayers.ContainsKey(playerId)))
            {
                throw new Codenation.Challenge.Exceptions.PlayerNotFoundException();
            }

            return DictPlayers[playerId].salary;
        }
        
        public List<long> GetTopPlayers(int top) //******
        {
            List<long> TopPlayers = new List<long>();
            return TopPlayers;
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            if ( !(DictTeams.ContainsKey(teamId)) || !(DictTeams.ContainsKey(visitorTeamId)))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

            if (DictTeams[visitorTeamId].corUniformePrincipal == DictTeams[teamId].corUniformePrincipal)
            {
                return DictTeams[visitorTeamId].corUniformeSecundario;
            }

            return DictTeams[visitorTeamId].corUniformePrincipal;
        }

    }
}

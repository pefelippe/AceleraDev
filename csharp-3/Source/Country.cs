using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Country
    {        
        public State[] Top10StatesByArea()
        {
            State[] states = new State[10];

            states[0] = new State("Amazonas", "AM");
            states[1] = new State("Pará", "PA");
            states[2] = new State("Amazonas", "MT");
            states[3] = new State("Amazonas", "MG");
            states[4] = new State("Amazonas", "BA");
            states[5] = new State("Amazonas", "MS");
            states[6] = new State("Amazonas", "GO");
            states[7] = new State("Amazonas", "MA");
            states[8] = new State("Amazonas", "RS");
            states[9] = new State("Amazonas", "TO");

            return states;
        }

    }
}

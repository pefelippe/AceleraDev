using System;
using System.Collections.Generic;
using System.Text;

namespace Aula03
{
    class CalculoGenerico<T> where T: ICalculoValor
    {
        private decimal _imposto = 0.05m;
        private decimal _lucro = 0.1m;

        public void CalcularValorUnitario(T obj)
        {
            obj.ValorFinal += obj.ValorBruto;
            obj.ValorFinal += obj.ValorBruto * _imposto;
            obj.ValorFinal += obj.ValorBruto * _lucro;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appbankomat
{
    internal class Banknoty
    {
        List<int> banks = new List<int>(6);
        public Banknoty()
        {
            banks.Add(0);
            banks.Add(0);
            banks.Add(0);
            banks.Add(0);
            banks.Add(0);
            banks.Add(0);
            /*banks[1] = 0;
            banks[1] = 0;
            banks[2] = 0;
            banks[3] = 0;
            banks[4] = 0;
            banks[5] = 0;*/

        }
        public int cash()
        {
            int ccash;
            ccash= banks[0]*500;
            ccash += banks[1] * 200;
            ccash += banks[2] * 100;
            ccash += banks[3] * 50;
            ccash += banks[4] * 20;
            ccash += banks[5] * 10;
            return ccash;
        }
        public void b500add(int amount)
        {
            banks.Insert(0, amount);
        }
        public void b200add(int amount)
        {
            banks.Insert(1, amount);
        }
        public void b100add(int amount)
        {
            banks.Insert(2, amount);
        }
        public void b50add(int amount)
        {
            banks.Insert(3, amount);
        }
        public void b20add(int amount)
        {
            banks.Insert(4, amount);
        }
        public void b10add(int amount)
        {
            banks.Insert(5, amount);
        }
        public int ilosc500()
        {
            return banks[0] * 500;
        }
        public int ilosc200()
        {
            return banks[1] * 200;
        }
        public int ilosc100()
        {
            return banks[2] * 100;
        }
        public int ilosc50()
        {
            return banks[3] * 50;
        }
        public int ilosc20()
        {
            return banks[4] * 20;
        }
        public int ilosc10()
        {
            return banks[5] * 10;
        }
        public int ilebanknotow()
        {
            int ile;
            ile = banks[0] ;
            ile += banks[1] ;
            ile += banks[2] ;
            ile += banks[3] ;
            ile += banks[4] ;
            ile += banks[5] ;
            return ile;
        }

    }
}

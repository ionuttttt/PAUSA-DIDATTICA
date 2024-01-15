using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pausa_didattica
{
    class persona
    {
        protected string nome;
        protected string cognome;

        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
            }

        }

        public string Cognome
        {
            get => cognome;
            set
            {
                cognome = value;
            }

        }

        public string scriviN()
        {
            string n = nome;
            return n;
        }

        public string scriviC()
        {
            string c = cognome;
            return c;
        }
    }

    class conto : persona
    {
        private float euro = 0;
        private bool chiudi;
        persona persona = new persona();

        public bool apri()
        {
            chiudi = false;
            return chiudi;
        }

        public bool chiuso()
        {
            chiudi = true;
            euro = 0;
            return chiudi;
        }

        public void deposita(float cifra)
        {
            euro += cifra;
        }

        public void preleva(float cifra)
        {
            euro -= cifra;
        }

        public float saldo()
        {
            float e = euro;
            return e;
        }


    }

    class banca
    {
        conto[] conto = new conto[100];
        private int s, n = -1, c;
        private string _n, _c;
        private string[] con=new string[100];


        public int S
        {
            get => s;
            set
            {
                s = value;
            }
        }

        public int cerca(string _n, string _c)
        {
             int c = -1;

            for (int i = 0; i < n; i++)
            {
                if (_n == conto[i].Nome && _c == conto[i].Cognome)
                {
                    c = i;

                    break;
                }
            }
            return c;
        }

        public void apriConto()
        {
            n++;
            conto[n] = new conto();
            conto[n].apri();
            con[n] = "aperto";
            Console.WriteLine("Inserisic il nome dell'utente");
            conto[n].Nome = Console.ReadLine();
            Console.WriteLine("Inserisic il cognome dell'utente");
            conto[n].Cognome = Console.ReadLine();

        }

        public void ChiudiConto()
        {
            Console.WriteLine("Inserisci il nome dell'utente");
            _n = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome dell'utente");
            _c = Console.ReadLine();
            c = cerca(_n, _c);
            if (c == -1)
            {
                Console.WriteLine("Utente non trovato");
            }
            else
            {
                con[c] = "chiuso";
                Console.WriteLine($"Erogazione saldo corrente di: {conto[c].saldo()}\nIl conto è stato chiuso");
                conto[c].chiuso();
            }
        }

        public void DepositaSuConto()
        {
            Console.WriteLine("Inserisci il nome dell'utente");
            _n = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome dell'utente");
            _c = Console.ReadLine();
            c = cerca(_n, _c);
            if (c == -1)
            {
                Console.WriteLine("Utente non trovato");
            }
            else
            {
                Console.WriteLine("Inserisci la cifra da depositare");
                conto[c].deposita(int.Parse(Console.ReadLine()));
            }

        }

        public void PrelevaDaConto()
        {
            Console.WriteLine("Inserisci il nome dell'utente");
            _n = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome dell'utente");
            _c = Console.ReadLine();
            c = cerca(_n, _c);
            if (c == -1)
            {
                Console.WriteLine("Utente non trovato");
            }
            else
            {
                Console.WriteLine("Inserisic la cifra da prelevare");
                conto[c].preleva(int.Parse(Console.ReadLine()));
            }
        }

        public void VediSaldoConto()
        {
            Console.WriteLine("Inserisci il nome dell'utente");
            _n = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome dell'utente");
            _c = Console.ReadLine();
            c = cerca(_n, _c);
            if (c == -1)
            {
                Console.WriteLine("Utente non trovato");
            }
            else
            {
                Console.WriteLine($"Il conto corrente è di: {conto[c].saldo()}");
            }
        }

        public void VediInfoConto()
        {
            Console.WriteLine("Inserisci il nome dell'utente");
            _n = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome dell'utente");
            _c = Console.ReadLine();
            c = cerca(_n, _c);
            if (c == -1)
            {
                Console.WriteLine("Utente non trovato");
            }
            else
            {
                Console.WriteLine($"Utente: {conto[c].scriviC()} {conto[c].scriviN()}\nSaldo {conto[c].saldo()}\nStato: {con[c]}");
            }
        }

        public bool esci(bool e)
        {
            e = false;
            return e;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool e = true;
            banca banca = new banca();
            do
            {
                Console.WriteLine($"Premi:\n1) Apri conto\n2) Chiudi conto\n3) Deposita sul conto\n4) Preleva dal conto\n5) Visualizza il saldo\n6) Vedi info\n7) esci");
                banca.S = int.Parse(Console.ReadLine());


                switch (banca.S)
                {
                    case 1: banca.apriConto(); break;
                    case 2: banca.ChiudiConto(); break;
                    case 3: banca.DepositaSuConto(); break;
                    case 4: banca.PrelevaDaConto(); break;
                    case 5: banca.VediSaldoConto(); break;
                    case 6: banca.VediInfoConto(); break;
                    case 7: e = banca.esci(e); break;
                }
            } while (e == true);



        }
    }
}

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
        protected string nome, cognome, stato, provincia;


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

        public string Stato
        {
            get => stato;
            set
            {
                stato = value;
            }

        }

        public string Provincia
        {
            get => provincia;
            set
            {
                provincia = value;
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
        private string chiudi;
        persona persona = new persona();

        public string apri()
        {
            chiudi = "aperto";
            return chiudi;
        }

        public string chiuso()
        {
            chiudi = "chiuso";
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
        private float p1;
        private string _n, _c,p;


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

            for (int i = 0; i <= n; i++)
            {
                if (_n == conto[i].Nome && _c == conto[i].Cognome)
                {
                    c = i;

                    break;
                }
            }
            return c;
        }

        public float cercaP(string p)
        {
            float c = 0;

            for (int i = 0; i <= n; i++)
            {
                if (p == conto[i].Provincia)
                {
                    c += conto[i].saldo();
                }
            }

            return c;
        }

        public void apriConto()
        {
            n++;
            conto[n] = new conto();
            conto[n].Stato=conto[n].apri();
            Console.WriteLine("Inserisic il nome dell'utente");
            conto[n].Nome = Console.ReadLine();
            Console.WriteLine("Inserisic il cognome dell'utente");
            conto[n].Cognome = Console.ReadLine();
            Console.WriteLine("Inserisci la regione dell'utente");
            conto[n].Provincia = Console.ReadLine();

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

                Console.WriteLine($"Erogazione saldo corrente di: {conto[c].saldo()}\nIl conto è stato chiuso");
                conto[c].Stato=conto[c].chiuso();
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
                Console.WriteLine($"Utente: {conto[c].scriviC()} {conto[c].scriviN()}\nSaldo {conto[c].saldo()}\nStato: {conto[c].Stato}");
            }
        }

        public bool esci(bool e)
        {
            e = false;
            return e;
        }

        public void VediSaldoProvincia()
        {
            Console.WriteLine("Inserisci la regione");
            p= Console.ReadLine();
            p1 = cercaP(p.ToString());
            Console.WriteLine($"Il saldo della regione {p} è di {p1 }");
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
                Console.WriteLine($"Premi:\n1) Apri conto\n2) Chiudi conto\n3) Deposita sul conto\n4) Preleva dal conto\n5) Visualizza il saldo\n6) Vedi info\n7) Visualizza saldo provincia\n8) Esci");
                banca.S = int.Parse(Console.ReadLine());


                switch (banca.S)
                {
                    case 1: banca.apriConto(); break;
                    case 2: banca.ChiudiConto(); break;
                    case 3: banca.DepositaSuConto(); break;
                    case 4: banca.PrelevaDaConto(); break;
                    case 5: banca.VediSaldoConto(); break;
                    case 6: banca.VediInfoConto(); break;
                    case 7: banca.VediSaldoProvincia(); break;
                    case 8: e = banca.esci(e); break;
                }
            } while (e == true);



        }
    }
}

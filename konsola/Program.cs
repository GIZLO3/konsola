internal class Program
{
    static int[] pesel = new int[11];
    private static void Main(string[] args)
    {
        LoadPESEL();
        if(CheckGender(pesel) == 'M')
            Console.WriteLine("Płeć: Mężczyzna");
        else
            Console.WriteLine("Płeć: Kobieta");
        VerifyPESEL(pesel);
    }
    static void LoadPESEL()
    {
        Console.WriteLine("Podaj PESEL: ");
        string _pesel = Console.ReadLine() ?? "";
        for (int i = 0; i < 11; i++)
        {
            pesel[i] = _pesel[i] - '0';
        }
    }

    /**********************************************
    nazwa funkcji: CheckGender
    opis funkcji: funkcja sprawdza płeć oosby na podstawie numeru PESEL
    parametry: _pesel - tablica liczb całkowitch przechowująca numer PESEL
    zwracany typ i opis: char - płeć w postaci 'K' - kobieta, 'M' - mężczyzna 
    autor: 00000000000
    ***********************************************/
    static char CheckGender(int[] _pesel)
    {
        if (_pesel[9] % 2 == 0)
        {
            return 'K';
        }
        else
        {
            return 'M';
        }
    }

    static bool VerifyPESEL(int[] _pesel)
    {
        int[] weight = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        int S = 0;
        for (int i = 0; i < 10; i++)
        {
            S += _pesel[i] * weight[i];
        }

        int M = S % 10;
        int R;

        if(M == 0)
        {
            R = 0;
        }
        else
        {
            R = 10 - M;
        }

        if(R == _pesel[10])
        {
            Console.WriteLine("Zgodna suma kontrolna.");
            return true;
        }
        else 
        {
            Console.WriteLine("Niezgodna suma kontrolna.");
            return false; 
        }
    }
}
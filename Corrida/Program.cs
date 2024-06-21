public class Program
{
    public static void Main()
    {
        Program p = new Program();

        object[] ultra = (object[])p.p_ultra();
        object[] super = (object[])p.p_super();
        object[] macio = (object[])p.p_macio();
        object[] medio= (object[])p.p_medio();
        object[] duro = (object[])p.p_duro();
        object[] chuva = (object[])p.p_chuva();

        string volTempo = (string)ultra[0];
        double kmL = (double)ultra[1];
        int volAcrs1Ini = (int)ultra[2];
        int volAcrs1Fim = (int)ultra[3];
        string volAcrs1T = (string)ultra[4];
        int volAcrs2Ini = (int)ultra[5];
        int volAcrs2Fim = (int)ultra[6];
        string volAcrs2T = (string)ultra[7];
        int limite = (int)ultra[8];
        Carro ultraCar = new Carro(volTempo, kmL,volAcrs1Ini,volAcrs1Fim,volAcrs1T,volAcrs2Ini,volAcrs2Fim,volAcrs2T,limite);

        kmL = (double)super[0];
        volAcrs1Ini = (int)super[2];
        volAcrs1Fim = (int)super[3];
        volAcrs1T = (string)super[4];
        volAcrs2Ini = (int)super[5];
        volAcrs2Fim = (int)super[6];
        volAcrs2T = (string)super[7];
        limite = (int)super[8];
        Carro superCar = new Carro(volTempo, kmL, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T,limite);

        kmL = (double)macio[0];
        volAcrs1Ini = (int)macio[2];
        volAcrs1Fim = (int)macio[3];
        volAcrs1T = (string)macio[4];
        volAcrs2Ini = (int)macio[5];
        volAcrs2Fim = (int)macio[6];
        volAcrs2T = (string)macio[7];
        limite = (int)macio[8];
        Carro macioCar = new Carro(volTempo, kmL, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T, limite);

        kmL = (double)medio[0];
        volAcrs1Ini = (int)medio[2];
        volAcrs1Fim = (int)medio[3];
        volAcrs1T = (string)medio[4];
        volAcrs2Ini = (int)medio[5];
        volAcrs2Fim = (int)medio[6];
        volAcrs2T = (string)medio[7];
        limite = (int)medio[8];
        Carro medioCar = new Carro(volTempo, kmL, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T, limite);

        kmL = (double)duro[0];
        volAcrs1Ini = (int)duro[2];
        volAcrs1Fim = (int)duro[3];
        volAcrs1T = (string)duro[4];
        volAcrs2Ini = (int)duro[5];
        volAcrs2Fim = (int)duro[6];
        volAcrs2T = (string)duro[7];
        limite = (int)duro[8];
        Carro duroCar = new Carro(volTempo, kmL, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T, limite);

        kmL = (double)chuva[0];
        volAcrs1Ini = (int)chuva[2];
        volAcrs1Fim = (int)chuva[3];
        volAcrs1T = (string)chuva[4];
        volAcrs2Ini = (int)chuva[5];
        volAcrs2Fim = (int)chuva[6];
        volAcrs2T = (string)chuva[7];
        limite = (int)chuva[8];
        Carro chuvaCar = new Carro(volTempo, kmL, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T, limite);

        Console.WriteLine($"PNEU ULTRA MACIO\n{ultraCar.gasolina}km/l\nTempo de volta: {ultraCar.voltabase}\n");

    }

    public object p_ultra()
    {
        double kmL = 3.8;
        string volTempo = "00:01:57.0";

        int volAcrs1Ini = 3;
        int volAcrs1Fim = 6;
        string volAcrs1T = "00:00:00.2";

        int volAcrs2Ini = 7;
        int volAcrs2Fim = 11;
        string volAcrs2T = "00:00:00.5";
        int limite = 11;

        return new object[] { kmL, volTempo, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T, limite };
    }

    public object p_super()
    {
        double kmL = 4.3;
        string volTempo = "00:01:59.0";

        int volAcrs1Ini = 3;
        int volAcrs1Fim = 10;
        string volAcrs1T = "00:00:00.4";

        int volAcrs2Ini = 11;
        int volAcrs2Fim = 19;
        string volAcrs2T = "00:00:00.8";
        int limite = 19;

        return new object[] { kmL, volTempo, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T, limite };
    }

    public object p_macio()
    {
        double kmL = 4.7;
        string volTempo = "00:02:03.0";

        int volAcrs1Ini = 3;
        int volAcrs1Fim = 15;
        string volAcrs1T = "00:00:00.7";

        int volAcrs2Ini = 16;
        int volAcrs2Fim = 27;
        string volAcrs2T = "00:00:01.0";
        int limite = 27;

        return new object[] { kmL, volTempo, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T, limite };
    }

    public object p_medio()
    {
        double kmL = 5.1;
        string volTempo = "00:02:05.0";

        int volAcrs1Ini = 3;
        int volAcrs1Fim = 19;
        string volAcrs1T = "00:00:00.9";

        int volAcrs2Ini = 26;
        int volAcrs2Fim = 42;
        string volAcrs2T = "00:00:01.2";
        int limite = 34;

        return new object[] { kmL, volTempo, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T, limite };
    }

    public object p_duro()
    {
        double kmL = 5.5;
        string volTempo = "00:02:09.0";

        int volAcrs1Ini = 3;
        int volAcrs1Fim = 25;
        string volAcrs1T = "00:00:01.1";

        int volAcrs2Ini = 26;
        int volAcrs2Fim = 42;
        string volAcrs2T = "00:00:01.5";
        int limite = 42;

        return new object[] { kmL, volTempo, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T, limite };
    }

    public object p_chuva()
    {
        double kmL = 3.7;
        string volTempo = "00:02:17.0";

        int volAcrs1Ini = 3;
        int volAcrs1Fim = 35;
        string volAcrs1T = "00:00:01.5";

        int volAcrs2Ini = 36;
        int volAcrs2Fim = 70;
        string volAcrs2T = "00:00:02.2";
        int limite = 70;

        return new object[] { kmL, volTempo, volAcrs1Ini, volAcrs1Fim, volAcrs1T, volAcrs2Ini, volAcrs2Fim, volAcrs2T, limite };
    }

    public string Gas(double l)
    {
        if (l < 19.99) { return "00:00:00.3"; }
        if (l < 39.99) { return "00:00:00.2"; }
        if (l < 59.99) { return "00:00:00.1"; }
        return "00:00:00";
    }

    public void Volta()
    {

    }

    public class Carro(string v, double g, double d1i, double d1f, string d1t, double d2i, double d2f, string d2t, int lim)
    {
        public string voltabase { get; set; } = v;
        public double gasolina { get; set; } = g;
        public double desgaste1Ini { get; set; } = d1i;
        public double desgaste1Fim { get; set; } = d1f;
        public string desgaste1T { get; set; } = d1t;
        public double desgaste2Ini { get; set; } = d2i;
        public double desgaste2Fim { get; set; } = d2f;
        public string desgaste2T { get; set; } = d2t;
        public int limite { get; set; } = lim;
    }





}

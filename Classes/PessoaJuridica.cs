namespace RecuperacaoUC9SA2.Classes
{
    public class PessoaJuridica : Pessoa
    {
        public string? cnpj { get; set; }

        //XX.XXX.XXX-0001/XX
        public bool ValidarCnpj(string cnpj)
        {
            if (cnpj.Length == 18)
            {
                if (cnpj.Substring(11, 4) == "0001")
                {
                    return true;
                }
            }

            return false;
        }

        //Método para inserir um objeto em um arquivo txt
        public void Inserir(PessoaJuridica pj)
        {
            using(StreamWriter sw = new StreamWriter($"{pj.Nome}.txt"))
            {
                sw.WriteLine($"{pj.Nome},{pj.Rendimento},{pj.cnpj}");
            }
        }

        //Método para ler um arquivo txt
        //[Felipe, 1000, xx.xxx.xxx-0001/xx] => [0,1,2] => 3 Posições 
        public PessoaJuridica Ler(string nomeArquivo)
        {
            PessoaJuridica pj = new PessoaJuridica();

            using(StreamReader sr = new StreamReader($"{nomeArquivo}.txt"))
            {
                string[] atributos = sr.ReadLine()!.Split(",");

                pj.Nome = atributos[0];
                pj.Rendimento = float.Parse(atributos[1]);
                pj.cnpj = atributos[2];
            }

            return pj;
        }

    }
}
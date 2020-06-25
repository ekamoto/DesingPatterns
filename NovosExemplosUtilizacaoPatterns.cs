using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDesingPatterns
{
    class NovosExemplosUtilizacaoPatterns
    {
        public void executar() {

            // Teste observer
            List<Acoes> lista = new List<Acoes>();
            lista.Add(new Correr());
            lista.Add(new Nadar());

            var pessoa = new Pessoa(lista);

            pessoa.DarVida();

            // Teste state
            var pessoaState = new PessoaState();

            pessoaState.verificaPressaoAlta();
            pessoaState.verificaSeEstaGordo();
            pessoaState.diagnostico();

            pessoaState.peso = 40;
            pessoaState.pressao = 15;
            pessoaState.verificaPressaoAlta();
            pessoaState.verificaSeEstaGordo();

            pessoaState.diagnostico();

            pessoaState.peso = 200;
            pessoaState.pressao = 15;
            pessoaState.verificaPressaoAlta();
            pessoaState.verificaSeEstaGordo();

            pessoaState.diagnostico();

            pessoaState.peso = 30;
            pessoaState.pressao = 50;
            pessoaState.verificaPressaoAlta();
            pessoaState.verificaSeEstaGordo();

            pessoaState.diagnostico();

            pessoaState.peso = 200;
            pessoaState.pressao = 50;
            pessoaState.verificaPressaoAlta();
            pessoaState.verificaSeEstaGordo();

            pessoaState.diagnostico();


            // Teste template method
            var maquinaFazerBolos = new MaquinaDeFazerBolos();

            maquinaFazerBolos.fazerBolo(new BoloDeChocolate());
            maquinaFazerBolos.fazerBolo(new BoloDeLaranja());
            maquinaFazerBolos.fazerBolo(new BoloMarina());
            maquinaFazerBolos.fazerBolo(new BoloCasamento());

        }
    }

    interface Acoes {

        void Executar();

    }

    class Correr : Acoes
    {
        public void Executar()
        {
            Console.WriteLine("Correndo");
        }
    }

    class Nadar : Acoes
    {
        public void Executar()
        {
            Console.WriteLine("Nadando");
        }
    }

    class Pessoa {

        List<Acoes> listaAcoes = new List<Acoes>();
        public Pessoa (List<Acoes> acoes)
        {
            listaAcoes = acoes;
        }

        public void DarVida() 
        {
            foreach (var acao in listaAcoes)
            {
                acao.Executar();
            }
        }
    }


    // Exemplo state
    interface EstadoFisico
    {
        void estaGordo(PessoaState pessoa);
        void pressaoAlta(PessoaState pessoa);
        void diagnostico();
    }

    class Saudavel : EstadoFisico
    {
        public void diagnostico()
        {
            Console.WriteLine("Está saudável");
        }

        public void estaGordo(PessoaState pessoa)
        {
            if (pessoa.peso > 100)
            {
                pessoa.estadoFisico = new Doente();
            }
        }

        public void pressaoAlta(PessoaState pessoa)
        {
            if (pessoa.pressao > 20)
            {
                pessoa.estadoFisico = new Doente();
            }
        }
    }

    class Doente : EstadoFisico
    {
        public void estaGordo(PessoaState pessoa)
        {
            if (pessoa.peso < 40)
            {
                pessoa.estadoFisico = new Saudavel();
            }
        }

        public void pressaoAlta(PessoaState pessoa)
        {
            if (pessoa.pressao < 15 && pessoa.pressao > 13)
            {
                pessoa.estadoFisico = new Saudavel();
            }
        }

        public void diagnostico()
        {
            Console.WriteLine("Está doente");
        }
    }

    class PessoaState
    {

        public EstadoFisico estadoFisico;

        public int peso = 30;
        public int pressao = 14;

        public PessoaState()
        {
            estadoFisico = new Saudavel();
        }

        public void verificaSeEstaGordo()
        {
            estadoFisico.estaGordo(this);
        }

        public void verificaPressaoAlta()
        {
            estadoFisico.pressaoAlta(this);
        }

        public void diagnostico()
        {
            this.estadoFisico.diagnostico();
        }

    }

    // Exemplo template method
    interface FazerBolo
    {
        void fazer();
    }

    class BoloDeLaranja : FazerBolo
    {
        public void fazer()
        {
            Console.WriteLine("Fazendo bolo de laranja");
        }
    }

    class BoloDeChocolate : FazerBolo
    {
        public void fazer()
        {
            Console.WriteLine("Fazendo bolo de chocolate");
        }
    }

    // O bolo perfeito é uma classe que abstrai 3 processos que podem ser reescrito
    abstract class BoloPerfeito : FazerBolo
    {

        public void fazer()
        {
            if (CondicaoMagica())
                SegredoMagico();
            else
                SegredoMagico2();

            Console.WriteLine("Fazendo bolo perfeito");
        }

        public abstract void SegredoMagico();
        public abstract void SegredoMagico2();
        public abstract bool CondicaoMagica();

    }

    class BoloMarina : BoloPerfeito
    {
        public override bool CondicaoMagica()
        {
            Random randNum = new Random();
            var numero = randNum.Next(100);

            if (numero % 2 == 0)
                return true;

            return false;
        }

        public override void SegredoMagico()
        {
            Console.WriteLine("Adicionando ingrediente mágico");
        }

        public override void SegredoMagico2()
        {
            Console.WriteLine("Macumbinha das brava");
        }
    }

    class BoloCasamento : BoloPerfeito
    {
        public override bool CondicaoMagica()
        {
            Random randNum = new Random();
            var numero = randNum.Next(100);

            if (numero > 50)
                return true;

            return false;
        }

        public override void SegredoMagico()
        {
            Console.WriteLine("Adicionando ingrediente mágico para casamento");
        }

        public override void SegredoMagico2()
        {
            Console.WriteLine("Compra um pronto de outra loja");
        }
    }

    // Essa máquina de fazer bolo faz qualquer tipo de bolo
    // ou seja se eu quiser passar outro tipo de bolo
    // é só eu criar um outro tipo herdado de fazer bolo e passar
    // que a máquina faz
    class MaquinaDeFazerBolos
    {

        public void fazerBolo(FazerBolo fazerbolo)
        {
            fazerbolo.fazer();
        }

    }
}

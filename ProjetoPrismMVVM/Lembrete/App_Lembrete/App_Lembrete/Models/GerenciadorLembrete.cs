using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Lembrete.Models
{
    class GerenciadorLembrete
    {
        private  List<Lembrete> Lista { get; set; }

        public void Salvar(Lembrete lembrete)
        {
            Lista = Listagem();
            Lista.Add(lembrete);

            SalvarNoProperties(Lista);
        }

        public void Deletar(int index)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);

            SalvarNoProperties(Lista);
        }

        public void Finalizar(int index, Lembrete lembrete)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);
            Lista.Add(lembrete);

            SalvarNoProperties(Lista);
        }

        public List<Lembrete> Listagem()
        {
            return ListagemNoProperties();
        }

        private void SalvarNoProperties(List<Lembrete> Lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }
            string JsonVal = JsonConvert.SerializeObject(Lista);
            App.Current.Properties.Add("Tarefas", JsonVal);
        }

        private List<Lembrete> ListagemNoProperties()

        {

            if (App.Current.Properties.ContainsKey("Lembrete"))
            {
                String JsonVal = (String)App.Current.Properties["Tarefas"];
                List<Lembrete> Lista = JsonConvert.DeserializeObject<List<Lembrete>>(JsonVal);
                return Lista;
            }
            return new List<Lembrete>();
        }
    }
}

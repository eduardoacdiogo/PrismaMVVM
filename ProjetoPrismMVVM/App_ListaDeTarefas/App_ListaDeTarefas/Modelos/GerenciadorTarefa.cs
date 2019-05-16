using System;
using System.Collections.Generic;
using System.Text;

namespace App_ListaDeTarefas.Modelos
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }
        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista.RemoveAt(index);

            Lista.Add(tarefa);
            SalvarNoProperties(Lista);
        }
        public void Salvar (Tarefa tarefa)
        {
            Lista.Add(tarefa);

            SalvarNoProperties(Lista);
        }
        public void Deletar(Tarefa tarefa)
        {
            Lista.Remove(tarefa);

            SalvarNoProperties(Lista);
        }
        public List<Tarefa> Listagem()
        {
            return ListageNoProperties();
        }
        private void SalvarNoProperties(List<Tarefa> Lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }

            App.Current.Properties.Add("Tarefas", Lista);
        }
        private List<Tarefa> ListageNoProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                return (List<Tarefa>)App.Current.Properties["Tarefas"];
            }

            return new List<Tarefa>();
        }
    }
}

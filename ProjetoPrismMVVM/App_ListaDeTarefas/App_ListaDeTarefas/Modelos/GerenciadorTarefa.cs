﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App_ListaDeTarefas.Modelos
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }
        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);
            tarefa.DataFinalizacao = DateTime.Now;
            Lista.Add(tarefa);
            SalvarNoProperties(Lista);
        }
        public void Salvar (Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.Add(tarefa);

            SalvarNoProperties(Lista);
        }
        public void Deletar(int index)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);

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
            string JsonVal = JsonConvert.SerializeObject(Lista);
            App.Current.Properties.Add("Tarefas", JsonVal);
        }
        private List<Tarefa> ListageNoProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                String JsonVal = (String)App.Current.Properties["Tarefas"];
                List<Tarefa> Lista = JsonConvert.DeserializeObject<List<Tarefa>>(JsonVal);
                return Lista;
            }
                return new List<Tarefa>();
        }
    }
}

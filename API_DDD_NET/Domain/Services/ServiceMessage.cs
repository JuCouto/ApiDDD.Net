using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _IMessage;

        public ServiceMessage(IMessage IMessage)
        {
            _IMessage = IMessage;
        }

        public async Task Adicionar(Message objeto)
        {
            var validaTitulo = objeto.ValidarPropriedadeString(objeto.Titulo, "Titulo");
            if (validaTitulo)
            {
                objeto.DataCadastro = DateTime.Now;
                objeto.DataAlteracao = DateTime.Now;
                objeto.Ativo = true;
                await _IMessage.Add(objeto);
            }
        }

        public async Task Atualizar(Message objeto)
        {
            var validaTitulo = objeto.ValidarPropriedadeString(objeto.Titulo, "Titulo");
            if (validaTitulo)
            {
                objeto.DataAlteracao = DateTime.Now;
                await _IMessage.Update(objeto);
            }
        }

        public async Task<List<Message>> ListarMenssagemAtiva()
        {
            return await _IMessage.ListarMessage(n => n.Ativo);
        }
    }
}

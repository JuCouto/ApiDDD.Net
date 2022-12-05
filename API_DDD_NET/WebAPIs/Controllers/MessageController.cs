﻿using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IMessage _IMessage;

        public MessageController(IMapper IMapper, IMessage IMessage)
        {
            _IMapper = IMapper;
            _IMessage = IMessage;
        }

        [Authorize] // Só consegue chamar esse endpoint quem tiver autorização.
        [Produces("application/json")]
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> Add(MessageViewModel message)
        {
            message.UserId = await RetornarIdUsuarioLogado();
            var messageMap = _IMapper.Map<Message>(message);
            await _IMessage.Add(messageMap);
            return messageMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Update")]
        public async Task<List<Notifies>> Update(MessageViewModel message)
        {
            var messageMap = _IMapper.Map<Message>(message);
            await _IMessage.Update(messageMap);
            return messageMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Delete")]
        public async Task<List<Notifies>> Delete(MessageViewModel message)
        {
            var messageMap = _IMapper.Map<Message>(message);
            await _IMessage.Delete(messageMap);
            return messageMap.Notifications;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/GetEntityById")]
        public async Task<MessageViewModel> GetEntityById(Message message)
        {
            message = await _IMessage.GetEntityById(message.Id);
            var messageMap = _IMapper.Map<MessageViewModel>(message);
            return messageMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/List")]
        public async Task<List<MessageViewModel>> List()
        {
            var mensagens = await _IMessage.List();
            var messageMap = _IMapper.Map<List<MessageViewModel>>(mensagens);
            return messageMap;
        }



        private async Task<string> RetornarIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;

        }


    }
}

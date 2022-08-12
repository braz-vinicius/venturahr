﻿using System.Collections.Generic;
using VenturaHR.Domain.Entities.Resposta;

namespace VenturaHR.Domain.Services
{
    public interface IRespostaService
    {
        void CreateResposta(Resposta resposta);
        void DeleteResposta(int id);
        Resposta GetResposta(int id);
        List<Resposta> RetrieveAllRespostas();
    }
}
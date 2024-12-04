﻿using appLoginASPCORE.Models;

namespace appLoginASPCORE.Repository.Contract
{
    public interface IColaboradorRepository
    {
        Colaborador Login(string Email, string Senha);

        void Cadastrar(Colaborador colaborador);

        void Atualizar(Colaborador colaborador);

        void AtualizarSenha(Colaborador colaborador);

        void Excluir(int id);

        Colaborador ObterColaborador(int id);

        List<Colaborador> ObterColaboradorPorEmail(string email);

        IEnumerable<Colaborador> ObterTodosColaborados();

    }
}

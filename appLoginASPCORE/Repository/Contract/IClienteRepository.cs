using appLoginASPCORE.Models;

namespace appLoginASPCORE.Repository.Contract
{
    public interface IClienteRepository
    {
        // Login Cliente

        Cliente Login(string email, string senha);

        // CRUD 
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);           
        void Excluir(int Id);
        Cliente ObterCliente(int Id);
        IEnumerable<Cliente> ObterTodosClientes();



    }
}

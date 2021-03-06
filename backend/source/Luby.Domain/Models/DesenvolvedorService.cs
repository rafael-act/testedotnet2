using Luby.Domain.Interfaces;
using System.Linq;

namespace Luby.Domain.Models
{
    public class DesenvolvedorService
    {
        private readonly IRepository<Desenvolvedor> _desenvolvedorRepository;

        public DesenvolvedorService(IRepository<Desenvolvedor> desenvolvedorRepository)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
        }

        public bool Save(int id, string nome, string cpf, string cargo, string email, string login, string senha)
        {
            var desenvolvedor = _desenvolvedorRepository.GetById(id);

            if (desenvolvedor == null)
            {
                desenvolvedor = new Desenvolvedor(nome, cpf, cargo, email, login, senha);
                try
                {
                    _desenvolvedorRepository.Save(desenvolvedor);
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }

            }
            else
                return true;//desenvolvedor.Update(nome, cpf,cargo, email, login, senha);
        }

        public bool Delete(int id)
        {
            var desenvolvedor = _desenvolvedorRepository.GetById(id);

            if (desenvolvedor != null)
            {
                try
                {
                    _desenvolvedorRepository.Delete(desenvolvedor);
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }

            }
            else
                return false;
        }

        public bool Login(string login, string senha)
        {
            var query = _desenvolvedorRepository.GetAll().Where(e=>e.Login==login && e.Senha==senha);
            if (query.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
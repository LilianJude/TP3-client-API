using ApplicationWebASPNET.Models.EntityFramework;
using ApplicationWebASPNET.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationWebASPNET.Models.DataManager
{
    public class CompteManager : IDataRepository<Compte>
    {
        readonly FilmsDBContext _filmsDbContext;

        public CompteManager(FilmsDBContext context)
        {
            _filmsDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Compte>>> GetAll()
        {
            return _filmsDbContext.Compte.ToList();
        }
        public async Task<ActionResult<Compte>> GetById(int id)
        {
            return _filmsDbContext.Compte
            .FirstOrDefault(e => e.CompteId == id);
        }
        public async Task<ActionResult<Compte>> GetByString(string mail)
        {
            return await _filmsDbContext.Compte
            .FirstOrDefaultAsync(e => e.Mel.ToUpper() == mail.ToUpper());
        }
        public async Task Add(Compte entity)
        {
            _filmsDbContext.Compte.Add(entity);

            await _filmsDbContext.SaveChangesAsync();
        }
        public async Task Update(Compte compte, Compte entity)
        {
            _filmsDbContext.Entry(compte).State = EntityState.Modified;
            compte.CompteId = entity.CompteId;
            compte.Nom = entity.Nom;
            compte.Prenom = entity.Prenom;
            compte.Mel = entity.Mel;
            compte.Rue = entity.Rue;
            compte.CodePostal = entity.CodePostal;
            compte.Ville = entity.Ville;
            compte.Pays = entity.Pays;
            compte.Latitude = entity.Latitude;
            compte.Longitude = entity.Longitude;
            compte.Pwd = entity.Pwd;
            compte.TelPortable = entity.TelPortable;
            compte.Favoris = entity.Favoris;

            await _filmsDbContext.SaveChangesAsync();
        }
        public async Task Delete(Compte compte)
        {
            _filmsDbContext.Compte.Remove(compte);

            await _filmsDbContext.SaveChangesAsync();
        }
    }
}

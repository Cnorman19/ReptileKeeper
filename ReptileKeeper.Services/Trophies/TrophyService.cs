using Microsoft.EntityFrameworkCore;
using ReptileKeeper.Core.Interfaces;
using ReptileKeeper.Core.Models.Achievements.Trophies;
using ReptileKeeper.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileKeeper.Services.Trophies
{
    public class TrophyService : ITrophyService
    {
        private readonly ApplicationDbContext _context;
        public TrophyService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new trophy.
        /// </summary>
        /// <param name="trophy">The trophy object to be created.</param>
        /// <returns>The created trophy object if operation is successful, otherwise null indicating failure to create.</returns>
        public async Task<Trophy?> CreateAsync(Trophy trophy)
        {
            await _context.Trophies.AddAsync(trophy);

            var result = await _context.SaveChangesAsync();

            return result == 1 ? trophy : null;
        }

        /// <summary>
        /// Updates a new trophy.
        /// </summary>
        /// <param name="trophy">The trophy object to be updated.</param>
        /// <returns>The updated trophy object if operation is successful, otherwise null indicating failure to updated.</returns>
        public async Task<Trophy?> UpdateAsync(Trophy trophy)
        {
            _context.Trophies.Update(trophy);

            var result = await _context.SaveChangesAsync();

            return result == 1 ? trophy : null;
        }

        /// <summary>
        /// Deletes a new trophy.
        /// </summary>
        /// <param name="trophy">The trophy object to be deleted.</param>
        /// <returns>The boolean object representing success or failure of the operation.</returns>
        public async Task<bool> DeleteAsync(Trophy trophy)
        {
            _context.Trophies.Remove(trophy);

            var result = await _context.SaveChangesAsync();

            return result == 1 ? true : false;
        }

        /// <summary>
        /// Gets an existing trophy object matching the passed in trophy parameter.
        /// </summary>
        /// <param name="id">The id of the trophy object to be searched for.</param>
        /// <returns>The trophy object if found, otherwise null indicating failure to find.</returns>
        public async Task<Trophy?> GetTrophy(string id) => await _context.Trophies.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        /// <summary>
        /// Gets all trophy objects.
        /// </summary>
        /// <returns>A collection of trophy objects</returns>
        public async Task<IEnumerable<Trophy>> GetTrophies() => await _context.Trophies.AsNoTracking().ToListAsync();

        /// <summary>
        /// Gets all trophy objects belonging to a particular user.
        /// </summary>
        /// /// <param name="userId">The userId of the user you would like to find trophies for.</param>
        /// <returns>A collection of trophy objects</returns>
        public async Task<IEnumerable<Trophy>> GetTrophiesForUser(string userId) => await _context.Trophies.AsNoTracking().Where(t => t.RecipientId == userId).ToListAsync();
    }
}

using ReptileKeeper.Core.Models.Achievements.Trophies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReptileKeeper.Core.Interfaces
{
    public interface ITrophyService
    {
        /// <summary>
        /// Creates a new trophy.
        /// </summary>
        /// <param name="trophy">The trophy object to be created.</param>
        /// <returns>The created trophy object if operation is successful, otherwise null indicating failure to create.</returns>
        Task<Trophy?> CreateAsync(Trophy trophy);

        /// <summary>
        /// Updates a new trophy.
        /// </summary>
        /// <param name="trophy">The trophy object to be updated.</param>
        /// <returns>The updated trophy object if operation is successful, otherwise null indicating failure to updated.</returns>
        Task<Trophy?> UpdateAsync(Trophy trophy);

        /// <summary>
        /// Deletes a new trophy.
        /// </summary>
        /// <param name="trophy">The trophy object to be deleted.</param>
        /// <returns>The boolean object representing success or failure of the operation.</returns>
        Task<bool> DeleteAsync(Trophy trophy);

        /// <summary>
        /// Gets an existing trophy object matching the passed in trophy parameter.
        /// </summary>
        /// <param name="id">The id of the trophy object to be searched for.</param>
        /// <returns>The trophy object if found, otherwise null indicating failure to find.</returns>
        Task<Trophy?> GetTrophy(string id);

        /// <summary>
        /// Gets all trophy objects.
        /// </summary>
        /// <returns>A collection of trophy objects</returns>
        Task<IEnumerable<Trophy>> GetTrophies();

        /// <summary>
        /// Gets all trophy objects belonging to a particular user.
        /// </summary>
        /// /// <param name="userId">The userId of the user you would like to find trophies for.</param>
        /// <returns>A collection of trophy objects</returns>
        Task<IEnumerable<Trophy>> GetTrophiesForUser(string userId);
    }
}

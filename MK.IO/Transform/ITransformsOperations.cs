﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using MK.IO.Models;

namespace MK.IO
{
    public interface ITransformsOperations
    {
        /// <summary>
        /// Retrieves a list of transforms for the subscription.
        /// </summary>
        /// <returns></returns>
        List<TransformSchema> List();

        /// <summary>
        /// Retrieves a list of transforms for the subscription.
        /// </summary>
        /// <returns></returns>
        Task<List<TransformSchema>> ListAsync();

        /// <summary>
        /// Delete a Transform.
        /// </summary>
        /// <param name="transformName"></param>
        void Delete(string transformName);

        /// <summary>
        /// Delete a Transform.
        /// </summary>
        /// <param name="transformName"></param>
        /// <returns></returns>
        Task DeleteAsync(string transformName);

        /// <summary>
        /// Get a Transform by name.
        /// </summary>
        /// <param name="transformName"></param>
        /// <returns></returns>
        TransformSchema Get(string transformName);

        /// <summary>
        /// Get a Transform by name.
        /// </summary>
        /// <param name="transformName"></param>
        /// <returns></returns>
        Task<TransformSchema> GetAsync(string transformName);

        /// <summary>
        /// Create or Update a new Transform.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        TransformSchema CreateOrUpdate(string transformName, TransformProperties properties);

        /// <summary>
        /// Create or Update a new Transform.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        Task<TransformSchema> CreateOrUpdateAsync(string transformName, TransformProperties properties);
    }
}
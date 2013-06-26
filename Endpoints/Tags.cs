﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models.Responses;
using RestSharp;

namespace InstaSharp.Endpoints
{
    public class Tags : InstaSharp.Endpoints.InstagramAPI {
        
        /// <summary>
        /// Tag Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class</param>
        public Tags(InstagramConfig config)
            : base("/tags/", config) { }

        /// <summary>
        /// Get information about a tag object.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="tagName">Return information about this tag.</param>
        public IRestResponse<TagResponse> Get(string tagName) {
            var request = base.Request("{tag}");
            request.AddUrlSegment("tag", tagName);
            return base.Client.Execute<TagResponse>(request);
        }

        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="tagName">Return information about this tag.</param>
        /// <param name="min_id">Return media before this min_id. If you don't want to use this parameter, use null.</param>
        /// <param name="max_id">Return media after this max_id. If you don't want to use this parameter, use null.</param>
        public IRestResponse<MediasResponse> Recent(string tagName, string min_id = "", string max_id = "") {
            var request = base.Request("{tag}/media/recent");
            request.AddUrlSegment("tag", tagName);
            request.AddParameter("min_id", min_id);
            request.AddParameter("max_id", max_id);
            
            return base.Client.Execute<MediasResponse>(request);
        }

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="searchTerm">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        public IRestResponse<TagsResponse> Search(string searchTerm) {
            var request = base.Request("search");
            request.AddParameter("q", searchTerm);
            return base.Client.Execute<TagsResponse>(request);
        }
    }
}

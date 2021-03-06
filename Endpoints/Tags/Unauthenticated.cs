﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Tags {
    public class Unauthenticated : InstagramAPI {

        public Unauthenticated(InstagramConfig config) : base(config, "/tags/") { }

        public TagResponse Get(string tagName) {
            return (TagResponse)Mapper.Map<TagResponse>(GetJson(tagName));
        }

        public string GetJson(string tagName) {
            string uri = string.Format(base.Uri + "{0}?client_id={1}", tagName, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public MediasResponse Recent(string tagName) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(tagName, null, null, 15));
        }

        public MediasResponse Recent(string tagName, int count)
        {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(tagName, null, null,count));
        }

        public MediasResponse Recent(string tagName, int count, string min_id, string max_id)
        {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(tagName, min_id, max_id, count));
        }

        public MediasResponse Recent(string tagName, string min_id, string max_id) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(tagName, min_id, max_id, 15));
        }

        private string RecentJson(string tagName, string min_id, string max_id, int count) {
            string uri = string.Format(base.Uri + "{0}/media/recent?client_id={1}&count={2}", tagName, InstagramConfig.ClientId,count);
            if (!string.IsNullOrEmpty(min_id)) uri += "&min_tag_id=" + min_id;
            if (!string.IsNullOrEmpty(max_id)) uri += "&max_tag_id=" + max_id;
            
            return HttpClient.GET(uri);
        }


        public TagsResponse Search(string searchTerm) {
            return (TagsResponse)Mapper.Map<TagsResponse>(SearchJson(searchTerm));
        }

        private string SearchJson(string searchTerm) {
            string uri = string.Format(base.Uri + "/search/?q={0}&client_id={1}", searchTerm, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }
    }
}

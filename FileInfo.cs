using System;
using System.Collections.Generic;
using System.Text;

namespace membooru
{
    public class Intensities
    {
        public double ne { get; set; }
        public double nw { get; set; }
        public double se { get; set; }
        public double sw { get; set; }
    }

    public class Representations
    {
        public string full { get; set; }
        public string large { get; set; }
        public string medium { get; set; }
        public string small { get; set; }
        public string tall { get; set; }
        public string thumb { get; set; }
        public string thumb_small { get; set; }
        public string thumb_tiny { get; set; }
    }

    public class FileInfo
    {
        public double aspect_ratio { get; set; }
        public int comment_count { get; set; }
        public DateTime created_at { get; set; }
        public object deletion_reason { get; set; }
        public string description { get; set; }
        public int downvotes { get; set; }
        public object duplicate_of { get; set; }
        public int faves { get; set; }
        public DateTime first_seen_at { get; set; }
        public string format { get; set; }
        public int height { get; set; }
        public bool hidden_from_users { get; set; }
        public int id { get; set; }
        public Intensities intensities { get; set; }
        public string mime_type { get; set; }
        public string name { get; set; }
        public object orig_sha512_hash { get; set; }
        public bool processed { get; set; }
        public Representations representations { get; set; }
        public int score { get; set; }
        public string sha512_hash { get; set; }
        public string source_url { get; set; }
        public bool spoilered { get; set; }
        public int tag_count { get; set; }
        public List<int> tag_ids { get; set; }
        public List<string> tags { get; set; }
        public bool thumbnails_generated { get; set; }
        public DateTime updated_at { get; set; }
        public string uploader { get; set; }
        public int uploader_id { get; set; }
        public int upvotes { get; set; }
        public string view_url { get; set; }
        public int width { get; set; }
        public double wilson_score { get; set; }

        
    }

}

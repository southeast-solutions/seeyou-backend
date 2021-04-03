﻿using Domain.Response.Abstract;

namespace Domain.Response.Other
{
    public class UploadImageResponse : FailableTaskResponse
    {
        public string Url { get; set; }
    }
}
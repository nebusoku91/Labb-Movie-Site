﻿namespace LMS.Common.DTOs
{
    public record ClickModel(string PageType, int Id);
    public record ClickReferenceModel(string PageType, int firstId, int secondId);
}

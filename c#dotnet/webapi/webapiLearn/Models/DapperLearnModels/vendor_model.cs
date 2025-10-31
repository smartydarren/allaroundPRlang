using System.ComponentModel.DataAnnotations;

namespace webapiLearn.Models;

public class Vendor
{
    public int Tvid { get; set; }
    public string? Ban { get; set; } //= string.Empty;
    public int Accountid { get; set; }
    public string RemitName { get; set; } = string.Empty;
}

public class ConfigResponseModel
{
    public DownloaderConfig downloaderConfig { get; set; }
    public AutomationConfigFile automationConfigFile { get; set; }

    public ConfigResponseModel()
    {
        downloaderConfig = new DownloaderConfig();
        automationConfigFile = new AutomationConfigFile();
    }
}

public class DownloaderConfig
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? WebUrl { get; set; }
    public string? SiteAgent { get; set; }
    public AutomationConfigFile automationConfigFile { get; set; }

    public DownloaderConfig()
    {
        automationConfigFile = new AutomationConfigFile();
    }
}

public class AutomationConfigFile
{
    public int Id { get; set; }
    [Key]
    public int DownloaderConfigId { get; set; }
    public string? FileName { get; set; }
    public string? Config { get; set; }
    //public DownloaderConfig DownloaderConfig { get; set; }    
    public ICollection<XPathMaps> xPathMaps { get; set; }

    public AutomationConfigFile()
    {
        xPathMaps = new List<XPathMaps>();
    }
}

public class XPathMaps
{
    [Key]
    public int Id { get; set; }
    public int ConfigFileId { get; set; }
    public string XPath { get; set; }
    public string Action { get; set; }      
}
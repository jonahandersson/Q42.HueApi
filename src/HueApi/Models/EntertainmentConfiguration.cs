using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HueApi.Models
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum EntertainmentConfigurationType
  {
    screen,
    music,
    //TODO: 3dspace
    other
  }

  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum EntertainmentConfigurationStatus
  {
    inactive, active
  }

  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum EntertainmentConfigurationStreamProxyMode
  {
    auto, manual
  }

  public class EntertainmentConfiguration : HueResource
  {
    [JsonPropertyName("configuration_type")]
    public EntertainmentConfigurationType ConfigurationType { get; set; }

    [JsonPropertyName("locations")]
    public Locations Locations { get; set; } = new();

    [JsonPropertyName("stream_proxy")]
    public StreamProxy StreamProxy { get; set; } = new();

    [JsonPropertyName("light_services")]
    public List<ResourceIdentifier> LightServices { get; set; } = new();

    [JsonPropertyName("channels")]
    public List<EntertainmentChannel> Channels { get; set; } = new();

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status")]
    public EntertainmentConfigurationStatus Status { get; set; }

    [JsonPropertyName("active_streamer")]
    public ResourceIdentifier? ActiveStreamer { get; set; }


  }

  public class EntertainmentChannel
  {
    [JsonPropertyName("channel_id")]
    public int ChannelId { get; set; }

    [JsonPropertyName("position")]
    public HuePosition Position { get; set; } = new();

    [JsonPropertyName("members")]
    public List<Member> Members { get; set; } = new();
  }

  public class Member
  {
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("service")]
    public ResourceIdentifier? Service { get; set; }
  }

  public class StreamProxy
  {
    [JsonPropertyName("mode")]
    public EntertainmentConfigurationStreamProxyMode Mode { get; set; }

    [JsonPropertyName("node")]
    public ResourceIdentifier? Node { get; set; }
  }

  public class HueServiceLocation
  {
    [JsonPropertyName("positions")]
    public List<HuePosition> Positions { get; set; } = new();

    [JsonPropertyName("service")]
    public ResourceIdentifier? Service { get; set; }

    [JsonPropertyName("position")]
    public HuePosition? Position { get; set; }
  }

  public class Locations
  {
    [JsonPropertyName("service_locations")]
    public List<HueServiceLocation> ServiceLocations { get; set; } = new();
  }
}

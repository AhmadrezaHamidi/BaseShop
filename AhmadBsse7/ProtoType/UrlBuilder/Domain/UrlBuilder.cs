using System;
namespace SmapleBuilder.Domain;

public class UrlBuilder
{
	private string host;
	private string port;
	private string protocol;
    private string reasource;

	public UrlBuilder WitheHost(string host)
	{
		this.host = host;
		return this;
	}

    public UrlBuilder WithePort(string port)
    {
        this.port = port;
        return this;
    }

    public UrlBuilder WitheProtocol(string protocol)
    {
        this.protocol = protocol;
        return this;
    }

    public UrlBuilder WitheReasource(string reasource)
    {
        this.reasource = reasource;
        return this;
    }

    public string Build()=>$"{protocol}://{reasource}:{port}";

}


open System
open System.Collections.Generic
open YamlDotNet.Serialization
open YamlDotNet.Serialization.NamingConventions
open System.IO

type Backend() = 
    member val TimeSeries = "" with get, set
    member val DataPoints = "" with get, set

type Postgres() =
    member val ConnectionString  = "" with get,set
    member val PoolSize = 0 with get,set

type Hbase() =
    member val Host = "" with get, set
    member val Port = 0 with get, set
    member val PoolSize = 0 with get, set
    member val BufferSize = 0 with get, set

type Zmq() = 
    member val Endpoint = "" with get, set
    member val Listener = "" with get, set

type Configuration() = 
    member val Backend = new Backend() with get,set
    member val Postgres = new Postgres() with get,set
    member val Hbase = new Hbase() with get, set
    member val Zmq = new Zmq() with get, set

let deserializer = new Deserializer(namingConvention = new CamelCaseNamingConvention())
let stream = File.OpenText("../../config.yaml")
let config = deserializer.Deserialize<Configuration>(stream)
stream.Close();

Console.WriteLine(config.Hbase.BufferSize)
Console.WriteLine(config.Postgres.ConnectionString)

# Grpc Demo : client-side streaming

## Overview

This demo demonstrates a **gRPC service** written in .NET that implements **client-side streaming**. Solution contains two project: grpc server, and console app as client. 
The server receives a stream of integers from a client, calculates their sum, and sends the result back to the client once the client-side streaming was completed.

The purpose of this demo is to showcase how to use gRPC for efficient communication in a **streaming scenario**, leveraging the HTTP/2 protocol for high-performance and low-latency communication.

## What is gRPC?

gRPC is a modern **Remote Procedure Call (RPC)** framework developed by Google. It enables communication between distributed systems using HTTP/2 as the transport protocol and Protocol Buffers (protobuf) as the data serialization format. gRPC is known for being:

- **Efficient**: Uses compact binary serialization (Protobuf).
- **Fast**: Built on HTTP/2 for multiplexing and low-latency communication.
- **Cross-Language**: Supports multiple programming languages, making it suitable for communication between range of different environments.

### Key Concepts of gRPC

- **Protocol Buffers**: Defines the contract between client and server using `.proto` files. Usually these files are the same, on both client and server side, creating a bluepring for communication between them. However they don't need to, as long as they follow **backward and forward compatibility rules**.
- **Streaming**: Supports various communication patterns, including:
    - Unary (single request, single response)
    - Server Streaming (single request, stream of responses)
    - Client Streaming (stream of requests, single response)
    - Bidirectional Streaming (stream of requests and responses)
- **Code Generation**: Automatically generates strongly typed client and server code from `.proto` files.

# CashValueNumberToWordsConverterClient

## Description
The CashValueNumberToWordsConverterClient is a WPF GUI, which accepts dollar currency value inputs and requests a service to convert the number into number words,
the communication with the server is based on GRPC.

## Run the client under Windows

- clone the master branch, the branch contains an already build version
- after cloning the application can be found under:
- [local project path]\CashValueNumberToWordsConverterClient\CashValueNumberToWordsConverterClient\bin\Release\netcoreapp3.1
- start the *CashValueNumberToWordsConverterClient* app
- in the *CashValueNumberToWordsConverterClient.dll.config* it is possible to manipulate the server address, it is set to https://localhost:5001 by default
- make sure, that the service [CashValueNumberToWordsConverterService](https://github.com/inggisi/CashValueNumberToWordsConverterService) runs with this address

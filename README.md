# CashValueNumberToWordsConverterClient

## Description
The CashValueNumberToWordsConverterClient is a WPF GUI, which accepts dollar currency value inputs and requests a service to convert the number into number words,
the communication with the server is based on GRPC.

## Run the client under Windows

- clone the master branch and open with Visual Studio or other appropriated IDE
- build the solution and start debugging or navigate to your solution folder and then into the project folder *CashValueNumberToWordsConverterClient*
- from there into \bin\[Debug|Release]\netcoreapp3.1 and start the *CashValueNumberToWordsConverterClient* application
- in the *CashValueNumberToWordsConverterClient.dll.config* it is possible to manipulate the server address, it is set to https://localhost:5001 by default
- make sure, that the service [CashValueNumberToWordsConverterService](https://github.com/inggisi/CashValueNumberToWordsConverterService) runs with this address

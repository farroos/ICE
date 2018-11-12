# ICE
Simulation Engine

To run, follow these steps

1. Compile MarketWatch solution and run the MarketWatch.Service project (WCF service).

  Note: To allow callbacks on the client machine, you may need to run this command from the commmand prompt with administrative privileges.
    netsh http add urlacl url=http://+:8000/myClient user=DOMAIN\user
    
2. Compile and start SimulationEngine (Console App), use the console window of the SimulationEngine to execute the available commands to Start/Stop/Exit the engine.

3. Compile and start ClientMarket Watch (Console App).

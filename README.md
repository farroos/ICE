# ICE
Simulation Engine

To run, follow these steps

1. Compile MarketWatch solution and run the MarketWatch.Service project.

  Note: To allow callbacks on the client machine, the may need to run this command needs from the commmand prompt with administrative privileges.
    netsh http add urlacl url=http://+:8000/myClient user=DOMAIN\user
    
2. Compile and start SimulationEngine.

3. Compile and start ClientMarket Watch.

4. Use the console window of the SimulationEngine to execute the available commands to Start/Stop/Exit the engine.

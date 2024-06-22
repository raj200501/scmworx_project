# SCMWorx Project

This repository contains the projects and tasks performed at SCMWorx. It includes the development of sophisticated software solutions to predict and mitigate supply chain risks using Java and C#.

## Project Structure

- **data**: Contains sample data.
- **models**: Contains pre-trained models.
- **src**: Contains source code for various components.
  - **java**: Java code for data preprocessing, analysis, and machine learning.
  - **csharp**: C# code for data preprocessing, analysis, and machine learning.

## How to Build and Run

### Prerequisites

- Java 8 or higher
- Maven
- .NET Core SDK

### Build and Run Java Code

```sh
cd src/java
mvn clean install
mvn exec:java -Dexec.mainClass="com.scmworx.Main"

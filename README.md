# DICOM Metadata API (Backend)

This is the backend for the DICOM metadata extraction application built with ASP.NET Core and the **fo-dicom** library. It exposes a simple API for uploading a DICOM file and retrieving its metadata.

## Features
- Upload DICOM files (.dcm)
- Parse the uploaded DICOM file
- Extract and return metadata as JSON (Patient Name, Study Date, Modality, etc.)

## Prerequisites
- .NET core 8
- Visual Studio 2022 or any compatible IDE
- NuGet packages: `fo-dicom`,


### Clone the Repository
```bash
git clone https://github.com/yourusername/dicom-backend.git
cd dicom-backend

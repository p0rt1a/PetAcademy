import { Component, ElementRef, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import { PetCertificateViewModel } from 'src/app/models/PetCertificateViewModel';
import { CertificateService } from 'src/app/services/certificate.service';
import { PetsService } from 'src/app/services/pets.service';

@Component({
  selector: 'app-certificate',
  templateUrl: './certificate.component.html',
  styleUrls: ['./certificate.component.css'],
})
export class CertificateComponent implements OnInit {
  certificate: PetCertificateViewModel = new PetCertificateViewModel(
    '',
    '',
    ''
  );

  constructor(
    private router: Router,
    private certificateService: CertificateService
  ) {}

  ngOnInit(): void {
    this.certificateService.certificate.subscribe((response) => {
      this.certificate = response;
    });
  }

  convertToPdf(elementId: string) {
    const element = document.getElementById(elementId);

    if (element != null) {
      html2canvas(element).then((canvas) => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jsPDF('landscape', 'pt', 'a4');

        const imgProps = pdf.getImageProperties(imgData);
        const pdfWidth = pdf.internal.pageSize.getWidth();
        const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;

        pdf.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight);
        pdf.save('certificate.pdf');
      });
    }
  }
}

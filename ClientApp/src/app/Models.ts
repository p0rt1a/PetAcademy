export class Category {
  id?: number;
  name: string;

  constructor(id: number, name: string) {
    this.id = id;
    this.name = name;
  }
}

export class AddTrainingDTO {
  training: Training;
  categoryIndexes: number[];

  constructor(training: Training, categoryIndexes: number[]) {
    this.training = training;
    this.categoryIndexes = categoryIndexes;
  }
}

export class Training {
  header: string;
  videoUrl: string;
  description: string;

  constructor(header: string, videoUrl: string, description: string) {
    this.header = header;
    this.videoUrl = videoUrl;
    this.description = description;
  }
}

// export class TrainingCategory {
//   trainingId: number;
//   categoryId: number;

//   constructor(trainingId: number, categoryId: number) {
//     this.trainingId = trainingId;
//     this.categoryId = categoryId;
//   }
// }

export class Training {
  id: number;
  header: string;
  videoUrl: string;
  description: string;
  level: string;
  trainerId: number;

  constructor(
    header: string,
    videoUrl: string,
    description: string,
    level: string,
    trainerId: number,
    id: number
  ) {
    this.id = id;
    this.header = header;
    this.videoUrl = videoUrl;
    this.level = level;
    this.description = description;
    this.trainerId = trainerId;
  }
}
export class TrainingDTO {
  training: Training;
  categoryIndexes: number[];

  constructor(training: Training, indexes: number[]) {
    this.training = training;
    this.categoryIndexes = indexes;
  }
}

export class Category {
  id: number;
  name: string;

  constructor(id: number, name: string) {
    this.id = id;
    this.name = name;
  }
}
export class CategoryTrainingDTO {
  categoryId: number;
  trainingId: number;

  constructor(categoryId: number, trainingId: number) {
    this.categoryId = categoryId;
    this.trainingId = trainingId;
  }
}

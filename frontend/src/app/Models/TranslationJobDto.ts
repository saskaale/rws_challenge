import NewTranslationJobDto from "./NewTranslationJobDto";

export default interface TranslationJobDto extends NewTranslationJobDto {
  status : string;
  id : number;
  price : number;
}

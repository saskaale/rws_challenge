import NewTranslationJobDto from "../Models/NewTranslationJobDto"
import TranslationJobDto from "../Models/TranslationJobDto"

const API_URL = "http://localhost:5000/api"

export const fetchAllJobs = () => {
  return fetch(`${API_URL}/jobs`).then(e=>e.json()) as Promise<TranslationJobDto[]>
}

export const createJob = (job: NewTranslationJobDto) => {
  return fetch(`${API_URL}/jobs`,{
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(job)
  }
  ).then(e=>e.json()) as Promise<TranslationJobDto>
}
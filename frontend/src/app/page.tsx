import Image from "next/image";
import { getJobs } from "@/libs/jobs";

export default async function Home() {
  const jobs = await getJobs();

  return (
    <main className="min-h-screen bg-gray-100">
      <section className="bg-gradient-to-r from-blue-600 to-indigo-700 text-white">
        <div className="max-w-6xl mx-auto px-6 py-16">
          <h1 className="text-5xl font-bold">
            AI Job Match
          </h1>

          <p className="mt-4 text-xl">
            Find jobs that match your skills and experience
          </p>

          <div className="mt-8 flex gap-3">
            <input
              type="text"
              placeholder="Search jobs..."
              className="flex-1 rounded-lg px-4 py-3 text-black"
            />

            <button className="bg-white text-blue-700 px-6 py-3 rounded-lg font-semibold">
              Search
            </button>
          </div>
        </div>
      </section>

      <section className="max-w-6xl mx-auto px-6 py-8">
        <h2 className="text-2xl font-bold mb-6">
          Available Jobs
        </h2>

        <div className="grid gap-6">
          {jobs.data.map((job: any, index: number) => (
            <div
              key={index}
              className="bg-white rounded-xl shadow-md p-6 hover:shadow-xl transition"
            >
              <h3 className="text-xl font-bold">
                {job.title}
              </h3>

              <p className="text-gray-600 mt-2">
                🏢 {job.company}
              </p>

              <p className="text-gray-600">
                📍 {job.location}
              </p>

              <div className="mt-4 flex justify-end">
                <button className="bg-blue-600 text-white px-4 py-2 rounded-lg">
                  View Job
                </button>
              </div>
            </div>
          ))}
        </div>
      </section>
    </main>
  );
}

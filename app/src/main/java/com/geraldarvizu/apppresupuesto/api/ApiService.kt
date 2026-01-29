package com.geraldarvizu.apppresupuesto.api

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.Body
import retrofit2.http.POST

data class LoginRequest(
    val email: String,
    val password: String
)

data class LoginResponse(
    val mensaje: String
)

interface ApiService {
    @POST("api/Usuario/Login")
    suspend fun login(@Body request: LoginRequest): LoginResponse
}

object ApiClient {
    private const val BASE_URL = "http://10.0.2.2:6000/" // conecta emulador con localhost

    val retrofit: ApiService by lazy {
        Retrofit.Builder()
            .baseUrl(BASE_URL)
            .addConverterFactory(GsonConverterFactory.create())
            .build()
            .create(ApiService::class.java)
    }
}

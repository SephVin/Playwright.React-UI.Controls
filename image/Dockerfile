FROM mcr.microsoft.com/playwright/dotnet:v1.51.0-jammy

COPY src ./tmp/src

RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash \
	&& apt update \
	&& apt install -y netcat \
	&& apt install -y nodejs \
	&& npm -g install npm@10 \
	&& curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --version 6.0.418 --install-dir /usr/share/dotnet 